using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Shared
{



    [Serializable]
    public class TheMetric
    {
        /// <summary>
        ///     True increasse, false decrease.
        /// </summary>
        private bool whatToDo;

        private decimal theValue;

        private int timeToSleep; // Miliseconds.

        public bool WhatToDo { get => whatToDo; set => whatToDo = value; }
        public decimal TheValue { get => theValue; set => theValue = value; }
        public int TimeToSleep { get => timeToSleep; set => timeToSleep = value; }

        public TheMetric()
        {
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/a514ff1d-91c2-4443-8469-117d7707a82d/passiing-class-object-via-named-pipes-in-c?forum=netfxbcl
            Random random = new Random();

            WhatToDo = IncreaseOrDecrease();

            TheValue = random.Next(1, 5);

            TimeToSleep = 250 * (int)random.Next(20, 40) / Thread.CurrentThread.ManagedThreadId;
        }

        private bool IncreaseOrDecrease()
        {
            Random random = new Random();

            return random.Next(0, 2) == 1 ? true : false;
        }

        public byte[] ObjectToByteArray()
        {
            if (this == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public TheMetric ByteArrayToObject()
        {
            if (this == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                
                return bf.Deserialize(ms) as TheMetric;
            }
        }
    }
}

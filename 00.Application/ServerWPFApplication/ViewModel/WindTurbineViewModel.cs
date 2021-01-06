﻿using Shared;
using System.ComponentModel;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using ServerWPFApplication.Model;
using ServerWPFApplication.Core;

namespace ServerWPFApplication.ViewModel
{
    public class WindTurbineViewModel : INotifyPropertyChanged
    {
        private WindTurbine windTurbine;
        private string textMessageTemperatura;
        private string textMessageHumedad;
        private string textMessagePresion;
        private EstacionMetereologica estacionMetereologica;
        private Task [] tasks;

        public string TextMessageTemperatura
        {
            get => textMessageTemperatura;

            set
            {
                if (value != textMessageTemperatura)
                {
                    textMessageTemperatura = value;
                    OnPropertyChanged(nameof(TextMessageTemperatura));
                }
            }
        }

        public string TextMessageHumedad
        {
            get => textMessageHumedad;

            set
            {
                if (value != textMessageHumedad)
                {
                    textMessageHumedad = value;
                    OnPropertyChanged(nameof(TextMessageHumedad));
                }
            }
        }

        public string TextMessagePresion
        {
            get => textMessagePresion;

            set
            {
                if (value != textMessagePresion)
                {
                    textMessagePresion = value;
                    OnPropertyChanged(nameof(TextMessagePresion));
                }
            }
        }

        public EstacionMetereologica EstacionMetereologica
        {
            get
            {
                return estacionMetereologica;
            }

            set
            {
                if (estacionMetereologica != value)
                {
                    estacionMetereologica = value;
                }
            }
        }

        public WindTurbine WindTurbine
        {
            get
            {
                return windTurbine;
            }

            set
            {
                if (windTurbine != value)
                {
                    windTurbine = value;
                }
            }
        }

        public Task[] Tasks { get => tasks; set => tasks = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public WindTurbineViewModel()
        {

        }

        public WindTurbineViewModel(WindTurbine windTurbine)
        {
            WindTurbine = windTurbine;
            EstacionMetereologica = new EstacionMetereologica();

            DispositivoTiempoActual dispositivoTiempoActual = new DispositivoTiempoActual();
            DispositivoEstadisticas dispositivoEstadisticas = new DispositivoEstadisticas();
            DispositivoPredictivo dispositivoPredictivo = new DispositivoPredictivo();

            estacionMetereologica.HaCambiadoElTiempo += dispositivoTiempoActual.ActualizarPantallaDipositivo;
            estacionMetereologica.HaCambiadoElTiempo += dispositivoEstadisticas.AñadirDatosParaLasEstadisticas;
            estacionMetereologica.HaCambiadoElTiempo += dispositivoPredictivo.AñadirDatosDePrediccion;

            TextMessageTemperatura = "Mensajes, sensor temperatura. Esperando conecxión...";
            TextMessageHumedad = "Mensajes, sensor humedad. Esperando conecxión...";
            TextMessagePresion = "Mensajes, sensor presion. Esperando conecxión...";

            Tasks = new Task[3]
            {
                
                Task.Run(() => InitializeNamedPipeServer(new NamedPipeNameBuilder(NamedPipesName.ThePipeNameTemperatura,"Turbine", WindTurbine.WindTurbineID).ToString(),TextMessageTemperatura, nameof(TextMessageTemperatura))),
                Task.Run(() => InitializeNamedPipeServer(new NamedPipeNameBuilder(NamedPipesName.ThePipeNameHumedad,"Turbine", WindTurbine.WindTurbineID).ToString(),TextMessageHumedad, nameof(TextMessageHumedad))),
                Task.Run(() => InitializeNamedPipeServer(new NamedPipeNameBuilder(NamedPipesName.ThePipeNamePresion,"Turbine", WindTurbine.WindTurbineID).ToString(), TextMessagePresion, nameof(TextMessagePresion))),
            };
        }

        private void InitializeNamedPipeServer(string namedPipeServer, string message, string nameOfProperty)
        {
            using (NamedPipeServerStream pipeServer = 
                    new NamedPipeServerStream(namedPipeServer, PipeDirection.In))
            {
                message = "NamedPipeServerStream object created.";

                // Wait for a client to connect
                message = "Waiting for client connection...";
                pipeServer.WaitForConnection();

                message = "Client connected.";

                using (StreamReader sr = new StreamReader(pipeServer))
                {
                    // Display the read text to the console
                    string temp;
                    while ((temp = sr.ReadLine()) != null)
                    {
                        // message = string.Format("Texto escrito por el cliente: {0}", temp);
                        
                        switch (nameOfProperty)
                        {
                            case nameof(TextMessageTemperatura):
                                TextMessageTemperatura  = string.Format("Texto escrito por el cliente: {0}", temp);
                                EstacionMetereologica.AumentarLaTemperaturaEnGrados(1);
                                break;
                            case nameof(TextMessageHumedad):
                                TextMessageHumedad = string.Format("Texto escrito por el cliente: {0}", temp);
                                EstacionMetereologica.AumentarLaHumedadEnPorcentaje(1);
                                break;
                            case nameof(TextMessagePresion):
                                TextMessagePresion = string.Format("Texto escrito por el cliente: {0}", temp);
                                EstacionMetereologica.AumentarLaPresionEnBares(1);
                                break;
                        }
                        OnPropertyChanged(nameof(EstacionMetereologica));
                        OnPropertyChanged(nameof(nameOfProperty));
                    }
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

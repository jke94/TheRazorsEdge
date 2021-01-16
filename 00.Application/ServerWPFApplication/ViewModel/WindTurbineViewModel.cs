using Shared;
using System.ComponentModel;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using ServerWPFApplication.Model;
using ServerWPFApplication.Core;
using Newtonsoft.Json;

namespace ServerWPFApplication.ViewModel
{
    public class WindTurbineViewModel : INotifyPropertyChanged
    {
        private WindTurbine windTurbine;
        private string textMessageTemperatura;
        private string textMessageHumedad;
        private string textMessagePresion;
        private WeatherStation estacionMetereologica;
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

        public WeatherStation EstacionMetereologica
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
            EstacionMetereologica = new WeatherStation();

            DeviceCurrentTime dispositivoTiempoActual = new DeviceCurrentTime();
            DeviceStatistics dispositivoEstadisticas = new DeviceStatistics();
            DevicePredictive dispositivoPredictivo = new DevicePredictive();

            EstacionMetereologica.TimeHasChanged += dispositivoTiempoActual.ActualizarPantallaDipositivo;
            EstacionMetereologica.TimeHasChanged += dispositivoEstadisticas.AñadirDatosParaLasEstadisticas;
            EstacionMetereologica.TimeHasChanged += dispositivoPredictivo.AñadirDatosDePrediccion;

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
                message = "NamedPipeServerStream object created and Waiting for client connection...";

                pipeServer.WaitForConnection();

                message = "Client connected.";

                using (StreamReader sr = new StreamReader(pipeServer))
                {
                    string temp;

                    while ((temp = sr.ReadLine()) != null)
                    {
                        var metric = JsonConvert.DeserializeObject<TheMetric>(temp.ToString());

                        switch (nameOfProperty)
                        {
                            case nameof(TextMessageTemperatura):

                                TextMessageTemperatura = string.Format("Texto escrito por el cliente: {0}", temp);
                                
                                if (metric.WhatToDo)
                                {
                                    EstacionMetereologica.IncreaseTheTemperatureInDegrees((int)metric.TheValue);
                                }
                                else
                                {
                                    EstacionMetereologica.DecreaseTheTemperatureInDegrees((int)metric.TheValue);
                                }

                                break;
                            case nameof(TextMessageHumedad):

                                TextMessageHumedad = string.Format("Texto escrito por el cliente: {0}", temp);

                                if (metric.WhatToDo)
                                {
                                    EstacionMetereologica.IncreaseHumidityInPercentage((int)metric.TheValue);
                                }
                                else
                                {
                                    EstacionMetereologica.DecreaseHumidityInPercentage((int)metric.TheValue);
                                }

                                break;
                            case nameof(TextMessagePresion):
                                TextMessagePresion = string.Format("Texto escrito por el cliente: {0}", temp);

                                if (metric.WhatToDo)
                                {
                                    EstacionMetereologica.IncreaseThePreasureInBar((int)metric.TheValue);
                                }
                                else
                                {
                                    EstacionMetereologica.DecreaseThePreasureInBar((int)metric.TheValue);
                                }

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

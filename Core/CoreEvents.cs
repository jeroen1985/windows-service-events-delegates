using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEventService.Core
{
    public delegate void EventDelegate();

    class CoreEvents
    {
        private const string _eventFilePath = @"c:\app\events.json";

        private EventLog _logger = new EventLog("Application") { Source = "WindowsEventService1" };

        public event EventDelegate WriteEventLog;
        public event EventDelegate StopListening;

        public CoreEvents()
        {
            RegisterEvents();
        }

        public void Execute()
        {
            bool keepListening = true;

            while (keepListening)
            {
                List<EventModel> currentEvents = JsonConvert.DeserializeObject<List<EventModel>>(File.ReadAllText(_eventFilePath));

                foreach (EventModel currentEvent in currentEvents)
                {
                    switch (currentEvent.Event)
                    {
                        case "WriteEventLog":
                            WriteEventLog();
                            break;
                        case "StopListening":
                            StopListening();
                            keepListening = false;
                            break;
                        default:
                            _logger.WriteEntry("Unkown event");
                            break;
                    }
                }
            }
        }

        private void RegisterEvents()
        {
            WriteEventLog += new EventDelegate(ProcessWriteEventLog);
            StopListening += new EventDelegate(ProcessStopListening);
        }

        private void ProcessWriteEventLog()
        {
            _logger.WriteEntry("Writing message in the windows event log");
        }

        private void ProcessStopListening()
        {
            _logger.WriteEntry("Service stopped listening");
        }
    }
}

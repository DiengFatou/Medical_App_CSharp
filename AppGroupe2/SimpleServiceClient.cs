using System;
using System.ServiceModel;
using MetierRvMedical;

namespace AppGroupe2.ServiceMetier
{
    public class SimpleServiceClient : IDisposable
    {
        private IService1 _service;
        private ChannelFactory<IService1> _factory;

        public SimpleServiceClient()
        {
            try
            {
                _factory = new ChannelFactory<IService1>("BasicHttpBinding_IService1");
                _service = _factory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur de connexion au service: " + ex.Message);
            }
        }

        public string TestConnection()
        {
            try
            {
                return _service.GetData(1);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors du test de connexion: " + ex.Message);
            }
        }

        public void Dispose()
        {
            if (_service != null && _service is ICommunicationObject)
            {
                try
                {
                    ((ICommunicationObject)_service).Close();
                }
                catch
                {
                    ((ICommunicationObject)_service).Abort();
                }
            }

            if (_factory != null)
            {
                _factory.Close();
            }
        }
    }
} 
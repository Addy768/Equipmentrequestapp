using System.Collections.Generic;
using EquipmentRequestApp.Models;

namespace EquipmentRequestApp.Repositories
{
    public class RequestRepository
    {
        private static List<Request> _requests = new List<Request>();

        public IEnumerable<Request> GetAllRequests()
        {
            return _requests;
        }

        public void AddRequest(Request request)
        {
            request.Id = _requests.Count + 1; 
            _requests.Add(request);
        }

        public void RemoveRequest(int id)
        {
            var request = _requests.Find(r => r.Id == id);
            if (request != null)
            {
                _requests.Remove(request);
            }
        }

        public Request GetRequestById(int id)
        {
            return _requests.Find(r => r.Id == id);
        }
    }
}

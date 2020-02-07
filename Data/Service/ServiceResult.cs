using System.Collections.Generic;

namespace scm.Service
{
    public class ServiceResult<T>{
        public bool isSuccess{get; set;}
        public T Result { get; set; }
        public List<string> Errors { get; set; }
    }
}
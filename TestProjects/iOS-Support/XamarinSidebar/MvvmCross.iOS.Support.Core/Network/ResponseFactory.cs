using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.Network;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core
{
    public static class ResponseFactory
    {
        public static Response CreateResponse(bool success, int errorCode)
        {
            return new Response(success, errorCode);
        }

        public static Response<T> CreateResponse<T>(bool success, int errorCode, T data = null) where T : class
        {
            return new Response<T>(success, errorCode, data);
        }

        public static bool IsSuccessful(Response response)
        {
            return response != null && response.Success;
        }
    }
}
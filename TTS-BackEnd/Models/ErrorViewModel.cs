using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TTS_BackEnd.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

}
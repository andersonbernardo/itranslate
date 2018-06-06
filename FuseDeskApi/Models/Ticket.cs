using FuseDeskApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuseDeskApi.Models
{
    public class Ticket
    {
        [HeaderCsvFileAttribute(HeaderName = "caseid")]
        public int caseid { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "id")]
        public int id { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "casenumber")]
        public string casenumber { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "casenum")]
        public string casenum { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "contactid")]
        public int? contactid { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "companyid")]
        public int? companyid { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "summary")]
        public string summary { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "repid")]
        public int? repid { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "repiddepartmentid")]
        public int? departmentid { get; set; }

        private string _detais;
        [HeaderCsvFileAttribute(HeaderName = "details")]
        public string details { get => !string.IsNullOrEmpty(_detais) ? Regex.Replace(_detais, @"\t|\n|\r", "") : string.Empty; set => _detais = value; }

        [HeaderCsvFileAttribute(HeaderName = "openedby")]
        public string openedby { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "date_opened")]
        public string date_opened { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "date_firstresponse")]
        public string date_firstresponse { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "date_lastresponse")]
        public string date_lastresponse { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "date_assigned")]
        public string date_assigned { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "date_closed")]
        public string date_closed { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "date_updated")]
        public string date_updated { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "date_rated")]
        public bool date_rated { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "date_requestedfeedback")]
        public bool date_requestedfeedback { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "status")]
        public string status { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "rating")]
        public object rating { get; set; }
        [HeaderCsvFileAttribute(HeaderName = "feedback")]
        public object feedback { get; set; }

        //private object _tags;
        //[HeaderCsvFileAttribute(HeaderName = "tags")]
        //public object tags { get => tags != null ? Regex.Replace(_tags.ToString(), @"\t|\n|\r", "") : string.Empty; set => _tags = value; }
    }
}

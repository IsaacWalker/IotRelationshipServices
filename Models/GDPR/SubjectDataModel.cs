using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Iot.Models.GDPR
{
    /// <summary>
    /// A model of personal data in a GDPR request
    /// </summary>
    public class SubjectDataModel
    {
        /// <summary>
        /// The Name of the personal data
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// The Categories of the Personal Data
        /// </summary>
        public IList<string> Categories { get; set; }


        /// <summary>
        /// Date the Personal Data was Collected
        /// </summary>
        public DateTime DateOfCollection { get; set; }


        /// <summary>
        /// The Date that this information will be deleted
        /// </summary>
        public DateTime DateOfDeletion { get; set; }


        /// <summary>
        /// Data
        /// </summary>
        public IDictionary<string,string> Data { get; set; }
    }
}

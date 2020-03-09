using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Iot.Models.GDPR
{
    /// <summary>
    /// A model of personal data in a GDPR request
    /// </summary>
    public class PersonalDataModel <T>
        where T : new()
    {
        /// <summary>
        /// The Name of the personal data
        /// </summary>
        public string PersonalDataName { get; set; }


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
        /// The personal data associated
        /// </summary>
        public T Data { get; set; }
    }
}

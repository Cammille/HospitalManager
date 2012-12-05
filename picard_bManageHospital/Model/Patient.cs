using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace picard_bManageHospital.Model
{
    class Patient : ServicePatient.Patient
    {        
        public Patient(ServicePatient.Patient servicePatient)
        {
            this.Id = servicePatient.Id;
            this.Firstname = servicePatient.Firstname;
            this.Name = servicePatient.Name;
            this.Birthday = servicePatient.Birthday;
            this.Observations = servicePatient.Observations;
            this.ExtensionData = servicePatient.ExtensionData;
        }
    }
}

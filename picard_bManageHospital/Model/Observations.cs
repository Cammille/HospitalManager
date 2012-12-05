using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace picard_bManageHospital.Model
{
    class Observations : ServicePatient.Observation
    {
        public Observations(ServicePatient.Observation serviceObservation)
        {
            this.BloodPressure = serviceObservation.BloodPressure;
            this.Comment = serviceObservation.Comment;
            this.Date = serviceObservation.Date;
            this.ExtensionData = serviceObservation.ExtensionData;
            this.Pictures = serviceObservation.Pictures;
            this.Prescription = serviceObservation.Prescription;
            this.Weight = serviceObservation.Weight;
        }
    }
}

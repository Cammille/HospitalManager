using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace picard_bManageHospital.DataAccess
{
    class Patient
    {
        public List<Model.Patient> GetListPatient()
        {
            try
            {
                //return new ServicePatient.ServicePatientClient().GetListPatient().ToList();
                return null;

            }
            catch (Exception ex)
            {
                //traitement exception ...
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

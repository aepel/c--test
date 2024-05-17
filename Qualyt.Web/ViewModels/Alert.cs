using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualyt.Web.ViewModels
{
    public enum AlertType
    {
        PatientWithoutConsent,
        TodayControl
    }

    public class Alert
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public object Params { get; set; }
        public AlertType Type { get; set; }
    }

    public class PatientWithoutConsentAlert : Alert
    {
        public PatientWithoutConsentAlert()
        {
            Type = AlertType.PatientWithoutConsent;
        }
        public long PatientId { get; set; }
        public string PatientName { get; set; }
    }

    public class TodayControlAlert : Alert
    {
        public TodayControlAlert()
        {
            Type = AlertType.TodayControl;
        }
        public long TreatmentId { get; set; }
        public string PatientName { get; set; }
    }
}

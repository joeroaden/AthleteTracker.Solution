using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
namespace AthleteTracker.Models
{
    public class Athlete
    {
        public Athlete()
        {
            this.JoinEntities = new HashSet<AthleteSponsor>();
            this.JoinEntities2 = new HashSet<AthleteSport>();
        }

        public int AthleteId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public virtual ICollection<AthleteSponsor> JoinEntities { get;}
        public virtual ICollection<AthleteSport> JoinEntities2 { get;}

    }
}
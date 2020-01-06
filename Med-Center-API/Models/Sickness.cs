using System;

namespace Med_Center_API.Models
{
    public class Sickness
    {
        public int id {get;set;}
        public string sicknessName{get;set;}
        public string sicknessDescription{get;set;}
        public Boolean cured {get;set;}
        public int appointmentId{get;set;}
    }
}
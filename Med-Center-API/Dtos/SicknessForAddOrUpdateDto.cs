using System;

namespace Med_Center_API.Dtos
{
    public class SicknessForAddOrUpdateDto
    {
        public string sicknessName{get;set;}
        public string sicknessDescription{get;set;}
        public Boolean cured {get;set;}
        public int appointmentId{get;set;}
    }
}
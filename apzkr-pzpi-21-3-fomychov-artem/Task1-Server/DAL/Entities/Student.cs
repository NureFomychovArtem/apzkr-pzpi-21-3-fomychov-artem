﻿namespace DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int StudyYeart { get; set; }
    }
}
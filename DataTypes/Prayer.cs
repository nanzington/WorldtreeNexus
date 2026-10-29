﻿namespace WorldtreeNexus.DataTypes {
    public class Prayer {
        public string Name = "";
        public string Book = "";
        public string Description = "";
        public int Level = 0; 

        public string SkillBuffed = "";
        public int AmountBuffed = 0;

        public bool Active = false;

        public List<string> ConflictsWith = new();

        public Prayer(string name, string book, int lev, string desc, string buffed = "", int amt = 0) {
            Name = name;
            Book = book;
            Level = lev; 
            SkillBuffed = buffed;
            AmountBuffed = amt;
            Description = desc;
        }
    }
}
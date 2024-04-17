﻿namespace Echo_HemAPI.Data.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public virtual Estate? Estate { get; set; }
        public virtual Realtor? Realtor { get; set; }
        public virtual RealtorFirm? RealtorFirm { get; set; }

        public Picture()
        {
            
        }

        public Picture(int id, string url)
        {
            PictureUrl = url;
            Id = id;
        }
    }
}

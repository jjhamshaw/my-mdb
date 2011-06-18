using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;


namespace MyMDB.Models.Entities
{
    [Table(Name = "films")]
    public class Film
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int ID { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string Genre { get; set; }
        [Column]
        public string Director { get; set; }
        [Column]
        public int Rating { get; set; }
        [Column]
        public DateTime ReleaseDate { get; set; }
    }
}
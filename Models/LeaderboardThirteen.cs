using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Models
{
    public class LeaderboardThirteen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OverallRank { get; set; }
        public double OverallScore { get; set; }
        [Key]
        public int CfId { get; set; }
        public string Name { get; set; }
        public int Workout01Rank { get; set; }
        public int Workout02Rank { get; set; }
        public int Workout03Rank { get; set; }
        public int Workout04Rank { get; set; }
        public int Workout05Rank { get; set; }
        public double Workout01Score { get; set; }
        public double Workout02Score { get; set; }
        public double Workout03Score { get; set; }
        public double Workout04Score { get; set; }
        public double Workout05Score { get; set; }
    }
}

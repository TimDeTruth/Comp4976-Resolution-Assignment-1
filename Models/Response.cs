using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ResolutionAssignment.Models;

public class Response
{
    public enum ResponseType{Yes,No, Maybe}

    [Key]
    public String? ResponseId { get; set; }
    public String? UserId { get; set; }
    [DisplayName("UserId")]
    [ForeignKey("UserId")]
    public ApplicationUser? User { get; set; }

    public String? ResolutionId { get; set; }
    [DisplayName("Resolution Id")]
    [ForeignKey("ResolutionId")]
    public Resolution? Resolution { get; set; }
    
    public DateTime ResponseDate { get; set; }
    public string? ResponseText { get; set; }
    public int ResponseVotes { get; set; }
    public ResponseType? ResponseStatus { get; set; }

}
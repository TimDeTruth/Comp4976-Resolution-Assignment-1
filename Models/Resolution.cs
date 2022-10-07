using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ResolutionAssignment.Models;
public class Resolution
{
    public enum ResolutionStatus {accpeted, rejected, pending}

    [Key]
    [DisplayName("Resolution ID")]
    public string? ResolutionId { get; set; }

    [DisplayName("Creation Date")]
    public DateTime? CreationDate { get; set; }

    public string? Abstract { get; set; }
    
    public ResolutionStatus? Status { get; set; }

    [DisplayName("User ID")]
    public String? UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser? Owner { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace App.Services.Models.Comment
{
    public class CreateCommentViewModel
    {
        public int RecipeId { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow.AddHours(2);

        [Required]
        [MinLength(5)]
        public string Content { get; set; }
    }
}

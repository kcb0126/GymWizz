using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymWizz.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gym Name")]
        public int GymId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class MainViewModel
    {
        [Display(Name = "Going to gym")]
        public bool IsGoing { get; set; }

        [Required]
        [Display(Name = "Going Time")]
        public int GoingTime { get; set; }

        [Required]
        [Display(Name = "Leaving Time")]
        public int LeavingTime { get; set; }

        [Display(Name = "Alarm")]
        public bool GetAlarm { get; set; }
    }

    public class PlanViewModel
    {
        // Abs workouts
        [Display(Name = "Leg Raises")]
        public bool LegRaises { get; set; }

        [Display(Name = "Sit ups")]
        public bool SitUps { get; set; }

        [Display(Name = "Ab bikes")]
        public bool AbBikes { get; set; }

        [Display(Name = "Sit up touching knees")]
        public bool SitUpTouchingKnees { get; set; }

        [Display(Name = "Plank from knees")]
        public bool PlankFromKnees { get; set; }

        // Arms workouts
        [Display(Name = "Barbell Curl")]
        public bool BarbellCurls { get; set; }

        [Display(Name = "Close-Grip Barbell Bench Press")]
        public bool CloseGripBarbellBenchPress { get; set; }

        [Display(Name = "Machine Preacher Curls")]
        public bool MachinePreacherCurls { get; set; }

        // Leg workouts
        [Display(Name = "Leg Extension")]
        public bool LegExtension { get; set; }

        [Display(Name = "Dumbbell Walking Lunge")]
        public bool DumbellWalkingLunge { get; set; }

        [Display(Name = "Standing Calf Raises")]
        public bool StandingCalfRaises { get; set; }

        [Display(Name = "Squat")]
        public bool Squat { get; set; }

        // Chest workouts
        [Display(Name = "Incline Dumbbell")]
        public bool InclineDumbbell { get; set; }

        [Display(Name = "Bench Press")]
        public bool BenchPress { get; set; }

        [Display(Name = "Flying")]
        public bool Flying { get; set; }

        [Display(Name = "Total Body")]
        public bool TotalBody { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

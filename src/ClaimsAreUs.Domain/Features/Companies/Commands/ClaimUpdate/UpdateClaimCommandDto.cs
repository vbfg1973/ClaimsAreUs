using System.Xml;
using FluentValidation;

namespace ClaimsAreUs.Domain.Features.Companies.Commands.ClaimUpdate
{
    /// <summary>
    ///     Update a claim
    /// </summary>
    public class UpdateClaimCommandDto
    {
        /// <summary>
        ///     Date claim is made
        /// </summary>
        public DateTime ClaimDate { get; set; }

        /// <summary>
        ///     Date claimed loss occurred
        /// </summary>
        public DateTime LossDate { get; set; }

        /// <summary>
        ///     The name of the person protected by the policy
        /// </summary>
        public string AssuredName { get; set; } = null!;

        /// <summary>
        ///     The amount claimed
        /// </summary>
        public decimal IncurredLoss { get; set; }

        /// <summary>
        ///     Claim now closed?
        /// </summary>
        public bool Closed { get; set; }
    }

    /// <summary>
    ///     Validation for update claim command dto
    /// </summary>
    public class UpdateClaimCommandDtoValidator : AbstractValidator<UpdateClaimCommandDto>
    {
        /// <summary>
        ///     ctor
        /// </summary>
        public UpdateClaimCommandDtoValidator()
        {
            RuleFor(dto => dto.IncurredLoss)
                .GreaterThan(0)
                .WithMessage("Incurred loss must be greater than zero");

            RuleFor(dto => dto.ClaimDate)
                .GreaterThan(dto => dto.LossDate)
                .WithMessage("Claim date must be more recent than loss date");
            
            RuleFor(dto => dto.AssuredName)
                .NotNull()
                .WithMessage("Assured name cannot be null")
                .NotEmpty()
                .WithMessage("Assured name cannot be empty");
        }
    }
}
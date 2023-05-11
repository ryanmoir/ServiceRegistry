using DiscoveryService.Models.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace DiscoveryService.Models.Dto.Controllers.HeartBeat
{
    public class HeartBeatAddDto : BaseAddDto
    {
        [Required]
        public long ServiceId { get; set; }

        public override bool Validate(out List<string> validationErrros)
        {
            base.Validate(out validationErrros);

            if ( ServiceId == 0)
                validationErrros.Add("ServiceId supplied was 0");

            return validationErrros.Count == 0 ? true : false;
        }
    }
}
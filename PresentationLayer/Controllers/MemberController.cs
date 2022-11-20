using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(MemberModel member)
        {
            await _memberService.Create(member);
            return Ok();
        }
        [HttpDelete("{idMember}")]
        public async Task<ActionResult> DeleteMember(int idMember)
        {
            await _memberService.DeleteMember(idMember);
            return Ok();
        }
        [HttpGet("AllMembers")]
        public async Task<ActionResult<IEnumerable<MemberModel>>> GetMembers()
        {
            IEnumerable<MemberModel> memberModels =await _memberService.GetMembers();
            return Ok(memberModels);
        }
        [HttpGet("NotBusyMember")]
        public async Task<ActionResult<IEnumerable<MemberModel>>> GetNotBusyMember()
        {
            IEnumerable<MemberModel> memberModels = await _memberService.GetNotBusyMember();
            return Ok(memberModels);
        }
        [HttpPost("ChangeBusy/{idMember}/{isBusy}")]
        public async Task<IActionResult> ChangeIsBusy(int idMember, bool isBusy)
        {
            await _memberService.ChangeIsBusy(idMember, isBusy);
            return Ok();
           

        }
    }
}

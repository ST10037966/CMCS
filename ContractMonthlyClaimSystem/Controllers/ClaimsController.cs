using ContactMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactMonthlyClaimSystem.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly ContactMonthlyClaimSystemContext _context;

        public ClaimsController(ContactMonthlyClaimSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitClaim(MonthlyClaim claim)
        {
            if (ModelState.IsValid)
            {
                claim.SubmissionDate = DateTime.Now;
                claim.Status = "Pending";

                _context.MonthlyClaims.Add(claim);
                await _context.SaveChangesAsync();

                // 🔹 Store a success message in TempData
                TempData["SuccessMessage"] = "You have successfully submitted your claim.";

                // 🔹 Redirect to clear the form (prevents duplicate submissions)
                return RedirectToAction("SubmitClaim");
            }
            return View(claim);
        }

        [HttpGet]
        public async Task<IActionResult> ReviewClaims()
        {
            var claims = await _context.MonthlyClaims
                .Include(c => c.Lecturer) // Ensures Lecturer data is loaded
                .ToListAsync();

            if (claims == null || !claims.Any())
            {
                TempData["NoClaimsMessage"] = "No claims have been submitted yet.";
            }

            return View(claims);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateClaimStatus(int id, string status)
        {
            var claim = await _context.MonthlyClaims.FindAsync(id);
            if (claim != null)
            {
                claim.Status = status;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ReviewClaims");
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument(IFormFile file, int claimId)
        {
            if (file != null && file.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var document = new Document
                {
                    FileName = file.FileName,
                    FilePath = path,
                    MonthlyClaimId = claimId
                };

                _context.Documents.Add(document);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ReviewClaims");
        }
    }
}


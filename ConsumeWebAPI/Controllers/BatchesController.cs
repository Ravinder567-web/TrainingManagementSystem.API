using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

public class BatchesController : Controller
{
    private readonly BatchService _batchService;

    public BatchesController(BatchService batchService)
    {
        _batchService = batchService;
    }

    public async Task<IActionResult> Index()
    {
        var batches = await _batchService.GetBatchesAsync();
        return View(batches); 
    }

    public async Task<IActionResult> Edit(int id)
    {
        var batch = await _batchService.GetBatchByIdAsync(id);
        if (batch == null) return NotFound();
        return View(batch);  
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Batch batch)
    {
        if (ModelState.IsValid)
        {
            var result = await _batchService.UpdateBatchAsync(batch);
            if (result)
                return RedirectToAction("Index");
        }
        return View(batch);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var batch = await _batchService.GetBatchByIdAsync(id);
        if (batch == null) return NotFound();
        return View(batch);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _batchService.DeleteBatchAsync(id);
        return RedirectToAction("Index");
    }
}

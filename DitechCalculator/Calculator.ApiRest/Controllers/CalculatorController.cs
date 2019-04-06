using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Calculator.BO.Interfaces;
using Calculator.Model.ApiModel.CanonicModel.v1;
using Calculator.Model.ApiModel.Request.v1;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calculator.ApiRest.Controllers {
    [Route("api/v1/[controller]")]
    public class CalculatorController : ControllerBase {
        private readonly ICalculatorSupervisor _calculatorSupervisor;

        public CalculatorController(ICalculatorSupervisor calculatorSupervisor) {
            _calculatorSupervisor = calculatorSupervisor;
        }

        [HttpGet("journal/query")]
        public async Task<IActionResult> GetAllOperations( CancellationToken ct = default(CancellationToken)) {
            try {
                var response = await _calculatorSupervisor.GetAllOperationAsync(ct);
                return Ok(response);
            } catch (Exception ex) {
                var response = new ResponseCanonic() {
                    ErrorCode = Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.InternalServerError),
                    ErrorStatus = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpGet("journal/query/{id}")]
        public async Task<IActionResult> GetOperationById(string id, CancellationToken ct = default(CancellationToken)) {
            try {
                var response =  await _calculatorSupervisor.GetOperationByIdAsync(id, ct);
                return Ok(response);
            }catch(Exception ex) {
                var response = new ResponseCanonic() {
                    ErrorCode = Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.InternalServerError),
                    ErrorStatus = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]RequestAdd requestAdd, CancellationToken ct = default(CancellationToken)) {
            try {
                bool save = Request.Headers.ContainsKey("X-Evl-Tracking-Id");
                var id = save ? Request.Headers["X-Evl-Tracking-Id"].ToString() : null;
                var response = await _calculatorSupervisor.AddAsync(requestAdd, save, id, ct);
                return Ok(response);
            } catch (Exception ex) {
                var response = new ResponseCanonic() {
                    ErrorCode = Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.InternalServerError),
                    ErrorStatus = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }
}

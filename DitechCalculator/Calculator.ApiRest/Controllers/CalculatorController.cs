using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Calculator.BO.Interfaces;
using Calculator.Model.ApiModel.CanonicModel.v1;
using Calculator.Model.ApiModel.Request.v1;
using Calculator.Model.ApiModel.Response.v1;
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
        [Produces(typeof(ResponseQuery))]
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
        [Produces(typeof(ResponseQuery))]
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

        [HttpPost("add")]
        [Produces(typeof(ResponseAdd))]
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

        [HttpPost("sub")]
        [Produces(typeof(ResponseSub))]
        public async Task<IActionResult> Sub([FromBody]RequestSub requestSub, CancellationToken ct = default(CancellationToken)) {
            try {
                bool save = Request.Headers.ContainsKey("X-Evl-Tracking-Id");
                var id = save ? Request.Headers["X-Evl-Tracking-Id"].ToString() : null;
                var response = await _calculatorSupervisor.SubAsync(requestSub, save, id, ct);
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

        [HttpPost("mult")]
        [Produces(typeof(ResponseMult))]
        public async Task<IActionResult> Mult([FromBody]RequestMult requestMult, CancellationToken ct = default(CancellationToken)) {
            try {
                bool save = Request.Headers.ContainsKey("X-Evl-Tracking-Id");
                var id = save ? Request.Headers["X-Evl-Tracking-Id"].ToString() : null;
                var response = await _calculatorSupervisor.MultAsync(requestMult, save, id, ct);
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

        [HttpPost("div")]
        [Produces(typeof(ResponseDiv))]
        public async Task<IActionResult> Div([FromBody]RequestDiv requestDiv, CancellationToken ct = default(CancellationToken)) {
            try {
                bool save = Request.Headers.ContainsKey("X-Evl-Tracking-Id");
                var id = save ? Request.Headers["X-Evl-Tracking-Id"].ToString() : null;
                var response = await _calculatorSupervisor.DivAsync(requestDiv, save, id, ct);
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

        [HttpPost("sqrt")]
        [Produces(typeof(ResponseSqrt))]
        public async Task<IActionResult> Sqrt([FromBody]RequestSqrt requestSqrt, CancellationToken ct = default(CancellationToken)) {
            try {
                bool save = Request.Headers.ContainsKey("X-Evl-Tracking-Id");
                var id = save ? Request.Headers["X-Evl-Tracking-Id"].ToString() : null;
                var response = await _calculatorSupervisor.SqrtAsync(requestSqrt, save, id, ct);
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

﻿using System;
using System.Linq;
using System.Web.Http.Controllers;

namespace Subvert.WebApi
{
	internal class EndpointActionSelector : IHttpActionSelector
	{
		public HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
		{
			var type = typeof(WebApiController);
			var method = type.GetMethod("Handle");

			return new ReflectedHttpActionDescriptor(
				controllerContext.ControllerDescriptor,
				method
				);
		}

		public ILookup<string, HttpActionDescriptor> GetActionMapping(HttpControllerDescriptor controllerDescriptor)
		{
			throw new NotImplementedException();
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Subvert
{
	public class EndpointAssemblyScanner : IEndpointStore
	{
		private readonly EndpointNamingConvention _namingConvention;
		private readonly Lazy<List<Endpoint>> _types;

		public EndpointAssemblyScanner(HostAssembly hostAssembly, EndpointNamingConvention namingConvention)
		{
			_namingConvention = namingConvention;
			_types = new Lazy<List<Endpoint>>(() => hostAssembly
				.Assembly
				.GetTypes()
				.Where(t => _namingConvention.IsMatch(t))
				.Select(t => new Endpoint(t, _namingConvention.GetName(t)))
				.ToList());
		}

		public IEnumerable<Endpoint> GetEndpoints()
		{
			return _types.Value;
		}

		public Endpoint GetEndpointByName(string name)
		{
			return _types.Value.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
		}
	}
}
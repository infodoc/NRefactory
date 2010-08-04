﻿// Copyright (c) 2010 AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under MIT X11 license (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ICSharpCode.NRefactory.TypeSystem
{
	[ContractClass(typeof(ITypeReferenceContract))]
	public interface ITypeReference : IFreezable
	{
		/// <summary>
		/// Resolves this type reference.
		/// </summary>
		IType Resolve(ITypeResolveContext context);
		
		/// <summary>
		/// Gets the base type. May return null.
		/// </summary>
		IType GetBaseType(ITypeResolveContext context);
		
		/// <summary>
		/// Gets inner classes (including inherited inner classes).
		/// </summary>
		IList<IType> GetNestedTypes(ITypeResolveContext context);

		/// <summary>
		/// Gets all methods that can be called on this return type.
		/// </summary>
		IList<IMethod> GetMethods(ITypeResolveContext context);
		
		/// <summary>
		/// Gets all properties that can be called on this return type.
		/// </summary>
		IList<IProperty> GetProperties(ITypeResolveContext context);
		
		/// <summary>
		/// Gets all fields that can be called on this return type.
		/// </summary>
		IList<IField> GetFields(ITypeResolveContext context);
		
		/// <summary>
		/// Gets all events that can be called on this return type.
		/// </summary>
		IList<IEvent> GetEvents(ITypeResolveContext context);
	}
	
	[ContractClassFor(typeof(ITypeReference))]
	abstract class ITypeReferenceContract : IFreezableContract, ITypeReference
	{
		IType ITypeReference.Resolve(ITypeResolveContext context)
		{
			Contract.Requires(context != null);
			Contract.Ensures(Contract.Result<IType>() != null);
			return null;
		}
		
		IType ITypeReference.GetBaseType(ITypeResolveContext context)
		{
			Contract.Requires(context != null);
			return null;
		}
		
		IList<IType> ITypeReference.GetNestedTypes(ITypeResolveContext context)
		{
			Contract.Requires(context != null);
			Contract.Ensures(Contract.Result<IList<IType>>() != null);
			return null;
		}

		IList<IMethod> ITypeReference.GetMethods(ITypeResolveContext context)
		{
			Contract.Requires(context != null);
			Contract.Ensures(Contract.Result<IList<IMethod>>() != null);
			return null;
		}
		
		IList<IProperty> ITypeReference.GetProperties(ITypeResolveContext context)
		{
			Contract.Requires(context != null);
			Contract.Ensures(Contract.Result<IList<IProperty>>() != null);
			return null;
		}
		
		IList<IField> ITypeReference.GetFields(ITypeResolveContext context)
		{
			Contract.Requires(context != null);
			Contract.Ensures(Contract.Result<IList<IField>>() != null);
			return null;
		}
		
		IList<IEvent> ITypeReference.GetEvents(ITypeResolveContext context)
		{
			Contract.Requires(context != null);
			Contract.Ensures(Contract.Result<IList<IEvent>>() != null);
			return null;
		}
	}
}
﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <author name="Daniel Grunwald"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	/// <summary>
	/// Default implementation for IParameter.
	/// </summary>
	public sealed class DefaultParameter : AbstractFreezable, IParameter, ISupportsInterning
	{
		string name = string.Empty;
		ITypeReference type = SharedTypes.UnknownType;
		IList<IAttribute> attributes;
		IConstantValue defaultValue;
		DomRegion region;
		byte flags;
		
		protected override void FreezeInternal()
		{
			type.Freeze();
			attributes = FreezeList(attributes);
			if (defaultValue != null)
				defaultValue.Freeze();
			base.FreezeInternal();
		}
		
		[ContractInvariantMethod]
		void ObjectInvariant()
		{
			Contract.Invariant(type != null);
			Contract.Invariant(name != null);
		}
		
		public string Name {
			get { return name; }
			set {
				if (value == null)
					throw new ArgumentNullException();
				Contract.EndContractBlock();
				CheckBeforeMutation();
				name = value;
			}
		}
		
		public ITypeReference Type {
			get { return type; }
			set {
				if (value == null)
					throw new ArgumentNullException();
				Contract.EndContractBlock();
				CheckBeforeMutation();
				type = value;
			}
		}
		
		public IList<IAttribute> Attributes {
			get {
				if (attributes == null)
					attributes = new List<IAttribute>();
				return attributes;
			}
		}
		
		public IConstantValue DefaultValue {
			get { return defaultValue; }
			set {
				CheckBeforeMutation();
				defaultValue = value;
			}
		}
		
		public DomRegion Region {
			get { return region; }
			set {
				CheckBeforeMutation();
				region = value;
			}
		}
		
		bool HasFlag(byte flag)
		{
			return (this.flags & flag) != 0;
		}
		void SetFlag(byte flag, bool value)
		{
			CheckBeforeMutation();
			if (value)
				this.flags |= flag;
			else
				this.flags &= unchecked((byte)~flag);
		}
		
		public bool IsRef {
			get { return HasFlag(1); }
			set { SetFlag(1, value); }
		}
		
		public bool IsOut {
			get { return HasFlag(2); }
			set { SetFlag(2, value); }
		}
		
		public bool IsParams {
			get { return HasFlag(4); }
			set { SetFlag(4, value); }
		}
		
		public bool IsOptional {
			get { return this.DefaultValue != null; }
		}
		
		void ISupportsInterning.PrepareForInterning(IInterningProvider provider)
		{
			CheckBeforeMutation();
			name = provider.InternString(name);
			type = provider.InternObject(type);
			attributes = provider.InternObjectList(attributes);
			defaultValue = provider.InternObject(defaultValue);
		}
		
		int ISupportsInterning.GetHashCodeForInterning()
		{
			return type.GetHashCode() ^ (attributes != null ? attributes.GetHashCode() : 0) ^ (defaultValue != null ? defaultValue.GetHashCode() : 0);
		}
		
		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			DefaultParameter p = other as DefaultParameter;
			return p != null && type == p.type && attributes == p.attributes
				&& defaultValue == p.defaultValue && region == p.region && flags == p.flags;
		}
	}
}
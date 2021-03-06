﻿using System;

namespace DD_Character.Utilitaire.Eventless
{
    public class Forwarder<TImpl, TValue> : IGetable, IEquate<TValue> where TImpl : class, IEquate<TValue>, IGetable
    {
        private readonly TImpl _impl;

        public Forwarder(TImpl impl)
        {
            _impl = impl;
        }

        protected TImpl Impl
        {
            get { return _impl; }
        }

        public event Action Changed
        {
            add { _impl.Changed += value; }
            remove { _impl.Changed -= value; }
        }

        public Func<TValue, TValue, bool> EqualityComparer
        {
            get { return _impl.EqualityComparer; }
            set { _impl.EqualityComparer = value; }
        }
    }
}
// <copyright file="EnumSelection.cs" company="Pyatygin S.Y.">
// Copyright (c) Pyatygin S.Y.. All rights reserved.
// </copyright>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SADT.Core.Extension
{
    /// <summary>
    /// EnumSelection.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public class EnumSelection<T> : INotifyPropertyChanged
        where T : struct, IComparable, IFormattable, IConvertible
    {
        private readonly bool isFlagged; // Enum uses flags?
        private readonly bool canDeselect; // Can be deselected? (Radio buttons cannot deselect, checkboxes can)
        private readonly T blankValue; // what is considered the "blank" value if it can be deselected?
        private T value; // stored value of the Enum

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSelection{T}"/> class.
        /// </summary>
        /// <param name="value">value.</param>
        public EnumSelection(T value)
            : this(value, false, default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSelection{T}"/> class.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="canDeselect">canDeselect.</param>
        public EnumSelection(T value, bool canDeselect)
            : this(value, canDeselect, default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSelection{T}"/> class.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="blankValue">blankValue.</param>
        public EnumSelection(T value, T blankValue)
            : this(value, true, blankValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSelection{T}"/> class.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="canDeselect">canDeselect.</param>
        /// <param name="blankValue">blankValue.</param>
        public EnumSelection(T value, bool canDeselect, T blankValue)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"{nameof(T)} must be an enum type"); // I really wish there was a way to constrain generic types to enums...
            }

            isFlagged = typeof(T).IsDefined(typeof(FlagsAttribute), false);

            this.value = value;
            this.canDeselect = canDeselect;
            this.blankValue = blankValue;
        }

        /// <summary>
        /// PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public T Value
        {
            get
            {
                return value;
            }

            set
            {
                if (this.value.Equals(value))
                {
                    return;
                }

                this.value = value;
                OnPropertyChanged();
                OnPropertyChanged("Item[]");
            }
        }

        /// <summary>
        /// this.
        /// </summary>
        /// <param name="key">key.</param>
        /// <returns>returns.</returns>
        [IndexerName("Item")]
        public bool this[T key]
        {
            get
            {
                int iKey = (int)(object)key;
                return isFlagged ? ((int)(object)value & iKey) == iKey : value.Equals(key);
            }

            set
            {
                if (isFlagged)
                {
                    int iValue = (int)(object)this.value;
                    int iKey = (int)(object)key;

                    if (((iValue & iKey) == iKey) == value)
                    {
                        return;
                    }

                    if (value)
                    {
                        Value = (T)(object)(iValue | iKey);
                    }
                    else
                    {
                        Value = (T)(object)(iValue & ~iKey);
                    }
                }
                else
                {
                    if (this.value.Equals(key) == value)
                    {
                        return;
                    }

                    if (!value && !canDeselect)
                    {
                        return;
                    }

                    Value = value ? key : blankValue;
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
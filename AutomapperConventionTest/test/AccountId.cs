namespace test
{

    using System;

    /// <summary>
    /// Value representing the identity of Account.
    /// </summary>
    public readonly struct AccountId : IComparable<AccountId>, IComparable<AccountId?>, IEquatable<AccountId>, IEquatable<AccountId?>
    {

        /// <summary>
        /// Determines whether the type of the Value property is nullable or not.
        /// This information is required in operator overloading methods where 
        /// values of nullable and/or non-nullable structs are compared.
        /// </summary>
        private static readonly bool ValueIsNullable = false;

        /// <summary>
        /// Initializes the <see cref="ValueIsNullable"/> static field.
        /// </summary>
        static AccountId()
        {
            Type type = typeof(AccountId).GetProperty("Value").PropertyType;
            ValueIsNullable = !type.IsValueType || (Nullable.GetUnderlyingType(type) != null);
        }

        /// <summary>
        /// Identity value of the AccountId.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new value of AccountId
        /// </summary>
        /// <param name="value">Identity value</param>
        public AccountId(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Creates a new value of AccountId
        /// </summary>
        /// <param name="localAccount">Identity value</param>
        /// <returns>Identity struct</returns>
        public static AccountId New(string localAccount) => new AccountId(localAccount);

        /// <summary>
        /// Checks whether two identity values are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(AccountId other) => CompareTo(other) == 0;


        /// <summary>
        /// Checks whether two identity values (one of them nullable) are equal.
        /// </summary>
        /// <param name="other">Other identity</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(AccountId? other) => CompareTo(other) == 0;

        /// <summary>
        /// Checks whether two values of AccountId are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is AccountId)
                return CompareTo((AccountId)obj) == 0;

            return false;
        }

        /// <summary>
        /// Compares values of two AccountId identities. If the value is nullable then
        /// null values precede non-null values. Non-null values are compared using
        /// CompareTo method of the value type.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>0 if two AccountId are equal, 1 if this AccountId comes after the other AccountId and -1 if this AccountId comes before the other AccountId.</returns>
        public int CompareTo(AccountId other)
        {
            if (ValueIsNullable)
            {
                // this code was generated from snippet
                // the snippet does not know whether the Value type chosen
                // is nullable or not. Therefore we disable the null comparison
                // warning just for convenience.
#pragma warning disable CS0472
                if (Value == null && other.Value == null)
                    return 0;

                if (Value == null && other.Value != null)
                    return -1;

                if (Value != null && other.Value == null)
                    return 1;
#pragma warning restore CS0472

            }
            return Value.CompareTo(other.Value);
        }

        /// <summary>
        /// Compares the struct with the other nullable struct value.
        /// </summary>
        /// <param name="other">Other nullable struct value</param>
        /// <returns>0 if two AccountId are equal, 1 if this AccountId comes after the other AccountId and -1 if this AccountId comes before the other AccountId.</returns>
        public int CompareTo(AccountId? other)
        {
            // if nullable has value, compare the struct like a non-nullable
            if (other.HasValue)
                return other.Value.CompareTo(this);

            // otherwise if the non-nullable value is null, the two are considered equal
#pragma warning disable CS0472
            if (ValueIsNullable && Value == null)
                return 0;
#pragma warning restore CS0472

            return 1;
        }

        /// <summary>
        /// Returns the hashcode of the AccountId.
        /// </summary>
        /// <returns>Hash code of AccountId</returns>
        public override int GetHashCode()
        {
            if (ValueIsNullable)
                return 0;

            return Value.GetHashCode();
        }

        /// <summary>
        /// Returns the string representation of AccountId
        /// </summary>
        /// <returns>String representation of AccountId</returns>
        public override string ToString()
        {
            if (ValueIsNullable)
            {
                // this code was generated from snippet
                // the snippet does not know whether the Value type chosen
                // is nullable or not. Therefore we disable the null comparison
                // warning just for convenience.
#pragma warning disable CS0472
                if (Value == null)
                    return "";
#pragma warning restore CS0472
            }

            return Value.ToString();
        }

        /// <summary>
        /// Method for allowing explicit conversion from the primitive type to the AccountId.
        /// </summary>
        /// <param name="value">Value of the identity</param>
        public static explicit operator AccountId(string value) => new AccountId(value);

        /// <summary>
        /// Method for allowing explicit conversion from AccountId to the identity primitive type.
        /// </summary>
        /// <param name="localAccount">Identity struct</param>
        public static explicit operator string(AccountId localAccount) => localAccount.Value;

        /// <summary>
        /// Overloads the equality operator for comparing the values of two AccountId.
        /// </summary>
        /// <param name="a">First AccountId</param>
        /// <param name="b">Second AccountId</param>
        /// <returns>True if two AccountId values are equal. False otherwise.</returns>
        public static bool operator ==(AccountId a, AccountId b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two AccountId.
        /// </summary>
        /// <param name="a">First AccountId</param>
        /// <param name="b">Second AccountId</param>
        /// <returns>True if two AccountId values are not equal. False otherwise.</returns>
        public static bool operator !=(AccountId a, AccountId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two AccountId with one
        /// Account being nullable. AccountId? null value is considered equal 
        /// with AccountId.Value == null. Therefore if the underlying type is nullable and the
        /// value contains null, that is considered the same thing as if the struct itself was null.
        /// </summary>
        /// <param name="a">First AccountId</param>
        /// <param name="b">Second AccountId</param>
        /// <returns>True if two AccountId values are equal. False otherwise.</returns>
        public static bool operator ==(AccountId? a, AccountId b) => b.CompareTo(a) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two AccountId with one
        /// Account being nullable.
        /// </summary>
        /// <param name="a">First AccountId</param>
        /// <param name="b">Second AccountId</param>
        /// <returns>True if two AccountId values are not equal. False otherwise.</returns>
        public static bool operator !=(AccountId? a, AccountId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two AccountId with one
        /// Account being nullable.
        /// </summary>
        /// <param name="a">First AccountId</param>
        /// <param name="b">Second AccountId</param>
        /// <returns>True if two AccountId values are equal. False otherwise.</returns>
        public static bool operator ==(AccountId a, AccountId? b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two AccountId with one
        /// Account being nullable.
        /// </summary>
        /// <param name="a">First AccountId</param>
        /// <param name="b">Second AccountId</param>
        /// <returns>True if two AccountId values are not equal. False otherwise.</returns>
        public static bool operator !=(AccountId a, AccountId? b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two AccountId with one
        /// Account being nullable.
        /// </summary>
        /// <param name="a">First AccountId</param>
        /// <param name="b">Second AccountId</param>
        /// <returns>True if two AccountId values are equal. False otherwise.</returns>
        public static bool operator ==(AccountId? a, AccountId? b) => CompareNullableWithNullable(a, b);

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two AccountId with one
        /// Account being nullable.
        /// </summary>
        /// <param name="a">First AccountId</param>
        /// <param name="b">Second AccountId</param>
        /// <returns>True if two AccountId values are not equal. False otherwise.</returns>
        public static bool operator !=(AccountId? a, AccountId? b) => !CompareNullableWithNullable(a, b);

        /// <summary>
        /// Private helper method for comparing two nullable AccountId values.
        /// </summary>
        /// <param name="a">First nullable value of AccountId</param>
        /// <param name="b">Second nullable value of AccountId</param>
        /// <returns>True if two AccountId values are not equal. False otherwise.</returns>
        private static bool CompareNullableWithNullable(AccountId? a, AccountId? b)
        {
            // if neither has value, they are both null and therefore are equal.
            if (!a.HasValue && !b.HasValue)
                return true;

            if (a.HasValue)
                return a.Value == b;

            return b.Value == a;
        }
    }

}

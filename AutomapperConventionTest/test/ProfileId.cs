namespace test
{

    using System;

    /// <summary>
    /// Value representing the identity of Profile.
    /// </summary>
    public readonly struct ProfileId : IComparable<ProfileId>, IComparable<ProfileId?>, IEquatable<ProfileId>, IEquatable<ProfileId?>
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
        static ProfileId()
        {
            Type type = typeof(ProfileId).GetProperty("Value").PropertyType;
            ValueIsNullable = !type.IsValueType || (Nullable.GetUnderlyingType(type) != null);
        }

        /// <summary>
        /// Identity value of the ProfileId.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new value of ProfileId
        /// </summary>
        /// <param name="value">Identity value</param>
        public ProfileId(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Creates a new value of ProfileId
        /// </summary>
        /// <param name="localProfile">Identity value</param>
        /// <returns>Identity struct</returns>
        public static ProfileId New(string localProfile) => new ProfileId(localProfile);

        /// <summary>
        /// Checks whether two identity values are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(ProfileId other) => CompareTo(other) == 0;


        /// <summary>
        /// Checks whether two identity values (one of them nullable) are equal.
        /// </summary>
        /// <param name="other">Other identity</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public bool Equals(ProfileId? other) => CompareTo(other) == 0;

        /// <summary>
        /// Checks whether two values of ProfileId are equal.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>True if identities are equal. False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ProfileId)
                return CompareTo((ProfileId)obj) == 0;

            return false;
        }

        /// <summary>
        /// Compares values of two ProfileId identities. If the value is nullable then
        /// null values precede non-null values. Non-null values are compared using
        /// CompareTo method of the value type.
        /// </summary>
        /// <param name="other">Other identity struct.</param>
        /// <returns>0 if two ProfileId are equal, 1 if this ProfileId comes after the other ProfileId and -1 if this ProfileId comes before the other ProfileId.</returns>
        public int CompareTo(ProfileId other)
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
        /// <returns>0 if two ProfileId are equal, 1 if this ProfileId comes after the other ProfileId and -1 if this ProfileId comes before the other ProfileId.</returns>
        public int CompareTo(ProfileId? other)
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
        /// Returns the hashcode of the ProfileId.
        /// </summary>
        /// <returns>Hash code of ProfileId</returns>
        public override int GetHashCode()
        {
            if (ValueIsNullable)
                return 0;

            return Value.GetHashCode();
        }

        /// <summary>
        /// Returns the string representation of ProfileId
        /// </summary>
        /// <returns>String representation of ProfileId</returns>
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
        /// Method for allowing explicit conversion from the primitive type to the ProfileId.
        /// </summary>
        /// <param name="value">Value of the identity</param>
        public static explicit operator ProfileId(string value) => new ProfileId(value);

        /// <summary>
        /// Method for allowing explicit conversion from ProfileId to the identity primitive type.
        /// </summary>
        /// <param name="localProfile">Identity struct</param>
        public static explicit operator string(ProfileId localProfile) => localProfile.Value;

        /// <summary>
        /// Overloads the equality operator for comparing the values of two ProfileId.
        /// </summary>
        /// <param name="a">First ProfileId</param>
        /// <param name="b">Second ProfileId</param>
        /// <returns>True if two ProfileId values are equal. False otherwise.</returns>
        public static bool operator ==(ProfileId a, ProfileId b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two ProfileId.
        /// </summary>
        /// <param name="a">First ProfileId</param>
        /// <param name="b">Second ProfileId</param>
        /// <returns>True if two ProfileId values are not equal. False otherwise.</returns>
        public static bool operator !=(ProfileId a, ProfileId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two ProfileId with one
        /// Profile being nullable. ProfileId? null value is considered equal 
        /// with ProfileId.Value == null. Therefore if the underlying type is nullable and the
        /// value contains null, that is considered the same thing as if the struct itself was null.
        /// </summary>
        /// <param name="a">First ProfileId</param>
        /// <param name="b">Second ProfileId</param>
        /// <returns>True if two ProfileId values are equal. False otherwise.</returns>
        public static bool operator ==(ProfileId? a, ProfileId b) => b.CompareTo(a) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two ProfileId with one
        /// Profile being nullable.
        /// </summary>
        /// <param name="a">First ProfileId</param>
        /// <param name="b">Second ProfileId</param>
        /// <returns>True if two ProfileId values are not equal. False otherwise.</returns>
        public static bool operator !=(ProfileId? a, ProfileId b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two ProfileId with one
        /// Profile being nullable.
        /// </summary>
        /// <param name="a">First ProfileId</param>
        /// <param name="b">Second ProfileId</param>
        /// <returns>True if two ProfileId values are equal. False otherwise.</returns>
        public static bool operator ==(ProfileId a, ProfileId? b) => a.CompareTo(b) == 0;

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two ProfileId with one
        /// Profile being nullable.
        /// </summary>
        /// <param name="a">First ProfileId</param>
        /// <param name="b">Second ProfileId</param>
        /// <returns>True if two ProfileId values are not equal. False otherwise.</returns>
        public static bool operator !=(ProfileId a, ProfileId? b) => !(a == b);

        /// <summary>
        /// Overloads the equality operator for comparing the values of two ProfileId with one
        /// Profile being nullable.
        /// </summary>
        /// <param name="a">First ProfileId</param>
        /// <param name="b">Second ProfileId</param>
        /// <returns>True if two ProfileId values are equal. False otherwise.</returns>
        public static bool operator ==(ProfileId? a, ProfileId? b) => CompareNullableWithNullable(a, b);

        /// <summary>
        /// Overloads the non-equality operator for comparing the values of two ProfileId with one
        /// Profile being nullable.
        /// </summary>
        /// <param name="a">First ProfileId</param>
        /// <param name="b">Second ProfileId</param>
        /// <returns>True if two ProfileId values are not equal. False otherwise.</returns>
        public static bool operator !=(ProfileId? a, ProfileId? b) => !CompareNullableWithNullable(a, b);

        /// <summary>
        /// Private helper method for comparing two nullable ProfileId values.
        /// </summary>
        /// <param name="a">First nullable value of ProfileId</param>
        /// <param name="b">Second nullable value of ProfileId</param>
        /// <returns>True if two ProfileId values are not equal. False otherwise.</returns>
        private static bool CompareNullableWithNullable(ProfileId? a, ProfileId? b)
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

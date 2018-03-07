﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

namespace DocumentFormat.OpenXml.Packaging
{
    /// <summary>
    /// Defines the DigitalSignatureOriginPart
    /// </summary>
    [OfficeAvailability(FileFormatVersions.Office2007)]
    [ContentType("application/vnd.openxmlformats-package.digital-signature-origin")]
    public partial class DigitalSignatureOriginPart : OpenXmlPart, IFixedContentTypePart
    {
        internal const string ContentTypeConstant = "application/vnd.openxmlformats-package.digital-signature-origin";
        internal const string RelationshipTypeConstant = "http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/origin";
        private static Dictionary<string, PartConstraintRule> _dataPartReferenceConstraint;
        private static Dictionary<string, PartConstraintRule> _partConstraint;

        /// <summary>
        /// Creates an instance of the DigitalSignatureOriginPart OpenXmlType
        /// </summary>
        internal protected DigitalSignatureOriginPart()
        {
        }

        /// <inheritdoc/>
        public sealed override string ContentType => ContentTypeConstant;

        /// <inheritdoc/>
        internal sealed override bool IsContentTypeFixed => true;

        /// <inheritdoc/>
        public sealed override string RelationshipType => RelationshipTypeConstant;

        /// <inheritdoc/>
        internal sealed override string TargetFileExtension => ".sigs";

        /// <inheritdoc/>
        internal sealed override string TargetName => "origin";

        /// <inheritdoc/>
        internal sealed override string TargetPath => "_xmlsignatures";

        /// <summary>
        /// Gets the XmlSignatureParts of the DigitalSignatureOriginPart
        /// </summary>
        public IEnumerable<XmlSignaturePart> XmlSignatureParts => GetPartsOfType<XmlSignaturePart>();

        /// <inheritdoc/>
        internal sealed override OpenXmlPart CreatePartCore(string relationshipType)
        {
            ThrowIfObjectDisposed();
            if (relationshipType is null)
            {
                throw new ArgumentNullException(nameof(relationshipType));
            }

            switch (relationshipType)
            {
                case XmlSignaturePart.RelationshipTypeConstant:
                    return new XmlSignaturePart();
            }

            throw new ArgumentOutOfRangeException(nameof(relationshipType));
        }

        /// <inheritdoc/>
        internal sealed override IDictionary<string, PartConstraintRule> GetDataPartReferenceConstraint()
        {
            if (_dataPartReferenceConstraint is null)
            {
                _dataPartReferenceConstraint = new Dictionary<string, PartConstraintRule>(StringComparer.Ordinal) { };
            }

            return _dataPartReferenceConstraint;
        }

        /// <inheritdoc/>
        internal sealed override IDictionary<string, PartConstraintRule> GetPartConstraint()
        {
            if (_partConstraint is null)
            {
                _partConstraint = new Dictionary<string, PartConstraintRule>(StringComparer.Ordinal)
                {
                    {
                        "http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/signature",
                        PartConstraintRule.Create<XmlSignaturePart>(false, true)
                    }
                };
            }

            return _partConstraint;
        }
    }
}

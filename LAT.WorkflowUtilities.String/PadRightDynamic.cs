﻿using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class PadRightDynamic : WorkFlowActivityBase
    {
        public PadRightDynamic() : base(typeof(PadRightDynamic)) { }

        [RequiredArgument]
        [Input("String To Pad")]
        public InArgument<string> StringToPad { get; set; }

        [RequiredArgument]
        [Input("Pad Character")]
        public InArgument<string> PadCharacter { get; set; }

        [RequiredArgument]
        [Input("Length")]
        public InArgument<int> Length { get; set; }

        [Output("Padded String")]
        public OutArgument<string> PaddedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToPad = StringToPad.Get(context);
            string padCharacter = PadCharacter.Get(context);
            int length = Length.Get(context);

            string paddedString = stringToPad;

            while (paddedString.Length < length)
            {
                paddedString += padCharacter;
            }

            PaddedString.Set(context, paddedString);
        }
    }
}
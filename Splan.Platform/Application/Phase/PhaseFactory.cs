namespace Splan.Platform.Application.Phase
{
    public static class PhaseFactory
    {
        public static Phase Create(string stage, string description)
        {
            if (string.IsNullOrWhiteSpace(stage))
                throw new ArgumentException(nameof(stage));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(nameof(description));

            var phase = new Phase()
            {
                Stage = stage,
                Description = description
            };

            return phase;
        }
    }
}

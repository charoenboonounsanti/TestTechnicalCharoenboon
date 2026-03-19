namespace Backend.Repositories;

using Backend.Models.Answer;
using Backend.Models.Question;
using Backend.Repositories.Interface;

public class InMemoryQuizRepository : IQuizRepository
{
    private readonly List<Question> _questions;

    public InMemoryQuizRepository()
    {
        _questions = InitializeMockData();
    }

    public Task<List<Question>> GetAllQuestionsAsync()
    {
        return Task.FromResult(_questions);
    }

    private List<Question> InitializeMockData()
    {
        return new List<Question>
        {
            new Question
            {
                Index = 1,
                Id = Guid.Parse("66142ce2-dc8e-4122-b95f-d4a5cfa18144"),
                Text = "2 + 3 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("3daf599e-a859-44f5-86bc-dccf366dbb72"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("2dc2c3cb-1a93-4c0f-b7f4-c01b89d01161"), Text = "4" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("3daf599e-a859-44f5-86bc-dccf366dbb72"), Text = "5" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("a2bc82a2-e40e-43c5-84ef-d7683165d03b"), Text = "6" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("eb9d85f7-876c-4e4f-a2d9-d6a36a3b5240"), Text = "7" }
                }
            },
            new Question
            {
                Index = 2,
                Id = Guid.Parse("327c94f1-3a9c-42b7-a6f6-d0862b228d71"),
                Text = "7 - 4 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("cc7cb837-59f6-42bc-b50f-0f7b89fe0e92"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("d7557415-1704-4f02-b809-b56426bef2c8"), Text = "1" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("f42cbd2b-6d1a-47b9-b6d2-7669c4b63480"), Text = "2" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("cc7cb837-59f6-42bc-b50f-0f7b89fe0e92"), Text = "3" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("93394608-c1d9-450b-99e8-a99f98b8c287"), Text = "4" }
                }
            },
            new Question
            {
                Index = 3,
                Id = Guid.Parse("c2f39cf6-85dd-4602-baeb-8530c6c17d1f"),
                Text = "5 x 2 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("318363bc-06be-4b1c-a9c4-87b93a7ddfab"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("131fce7b-4b46-4d2d-9d67-d734286703d8"), Text = "7" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("7c7064e6-794c-42ef-9d88-df1fced48904"), Text = "8" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("a70c4e4d-b93e-4a96-86b7-b1015eb89b93"), Text = "9" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("318363bc-06be-4b1c-a9c4-87b93a7ddfab"), Text = "10" }
                }
            },
            new Question
            {
                Index = 4,
                Id = Guid.Parse("b21db0aa-bfe9-4b3d-bf34-545ab428cc91"),
                Text = "12 / 3 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("bd4c2dfb-b536-47ba-84f0-2516fa53a7a6"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("bd4c2dfb-b536-47ba-84f0-2516fa53a7a6"), Text = "4" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("3d0e9a4b-8b34-42a1-a2dd-31bb48cd7e20"), Text = "3" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("1376769f-4f77-4ba9-8801-35b1a4cd0e56"), Text = "5" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("4ada25eb-e2df-46bc-820d-3146bccca32c"), Text = "6" }
                }
            },
            new Question
            {
                Index = 5,
                Id = Guid.Parse("f2563794-ce34-4f6b-ba1f-42c7db9383c2"),
                Text = "9 + 6 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("0e437ce3-95df-4fdd-ac32-0f4ca8e80e92"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("8b2b8bf0-1810-4012-812e-7b8cf13ce740"), Text = "13" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("de4f21f6-b7ba-4c7c-a0cf-c9334d418f9b"), Text = "14" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("0e437ce3-95df-4fdd-ac32-0f4ca8e80e92"), Text = "15" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("1710c083-8a5a-4c41-a24d-ab89865fa3a3"), Text = "16" }
                }
            },
            new Question
            {
                Index = 6,
                Id = Guid.Parse("8e3d744d-4551-4426-9266-337d25b4300e"),
                Text = "10 - 7 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("47f179eb-c3a0-47fc-be11-e1531faba1be"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("03515f6c-c88e-444e-adcf-ab1c8eb95804"), Text = "2" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("47f179eb-c3a0-47fc-be11-e1531faba1be"), Text = "3" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("9ab8a63b-573f-4eae-b2be-7549ca633f26"), Text = "4" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("04d3252a-e108-47b1-813b-9e26e921d3dd"), Text = "5" }
                }
            },
            new Question
            {
                Index = 7,
                Id = Guid.Parse("ec5006fc-5d42-4bcb-ad38-0dc1af652fdb"),
                Text = "3 x 3 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("d85cf376-79cc-4831-aa29-1ec43f6ef686"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("d85cf376-79cc-4831-aa29-1ec43f6ef686"), Text = "9" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("8dd6e32d-8be0-44cb-b7fa-d8c809667512"), Text = "6" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("d7d24360-0338-4dd2-890f-f85fbd884a80"), Text = "12" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("80d5a0b7-52b2-489b-a5cb-d38458fb3295"), Text = "8" }
                }
            },
            new Question
            {
                Index = 8,
                Id = Guid.Parse("e904dbda-0f03-4627-a724-6e3bc8d31337"),
                Text = "16 / 4 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("b9c420c0-3b9b-4bf8-a100-d7fa52e66640"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("693e6a38-4d0d-46e4-8c41-fcfaf7e6267f"), Text = "2" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("1a54ea81-cf11-4e10-9297-c1bf7de5582f"), Text = "3" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("a0c83a50-c18e-4344-b4a4-5aec8ef93a7f"), Text = "5" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("b9c420c0-3b9b-4bf8-a100-d7fa52e66640"), Text = "4" }
                }
            },
            new Question
            {
                Index = 9,
                Id = Guid.Parse("2807860d-bb3a-460f-b7f3-83f40d62463a"),
                Text = "8 + 1 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("8d2d6985-c989-49ec-a28f-dd6ed032afcd"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("9afc9a8c-2fb6-4ead-ae9d-0d10f9d301ef"), Text = "8" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("8d2d6985-c989-49ec-a28f-dd6ed032afcd"), Text = "9" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("7d6ac1d9-ae12-4d66-a0bb-336774726a32"), Text = "10" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("b46f544d-f81d-45ab-bf76-f1d8c49ae5c3"), Text = "11" }
                }
            },
            new Question
            {
                Index = 10,
                Id = Guid.Parse("fb2af1d9-2a44-4e9a-ae96-cf327d9d3e4b"),
                Text = "14 - 5 เท่ากับเท่าไร",
                CorrectAnswerId = Guid.Parse("f8867c6e-c3d9-4d93-8935-a9f987bc00e8"),
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Index = 1, Id = Guid.Parse("f23d26b9-1795-4768-b4b5-e604a0011ee0"), Text = "7" },
                    new AnswerOption { Index = 2, Id = Guid.Parse("4ab8f16a-16f1-44e8-8e26-8845fb0f2235"), Text = "8" },
                    new AnswerOption { Index = 3, Id = Guid.Parse("f8867c6e-c3d9-4d93-8935-a9f987bc00e8"), Text = "9" },
                    new AnswerOption { Index = 4, Id = Guid.Parse("6b6f31b7-2c0e-469c-93af-8d13fa0223b4"), Text = "10" }
                }
            }
        };
    }
}

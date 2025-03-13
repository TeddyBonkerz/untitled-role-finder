

using Microsoft.SemanticKernel;

public class JobModel {

    public string Company { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public string Experience { get; set; }
}

public class JobsPlugin {
    private readonly List<JobModel> jobs = new() {
        new JobModel {Company = "Google", Title = "Software Engineer II", Description = "This role requires skill like java, kubernetes, and knownledge of cloud platforms.", Experience = "Mid Level"},
        new JobModel {Company = "Affirm", Title = "Software Engineer II", Description = "This role requires skill like typscript, javascript and knowledge of frontend frameworks.", Experience = "Mid Level"},
        new JobModel {Company = "Hashicorp", Title = "Software Engineer Manager", Description = "This role requires skill like leadership, mentorship, people management and 10 years of designing applications at a high level.", Experience = "Manager"},
        new JobModel {Company = "Google", Title = "Staff Software Engineer", Description = "This role requires skill like java, kubernetes, and 7 years of designing distributed systems.", Experience = "Senior Level"},
        new JobModel {Company = "Github", Title = "Senior Software Engineer", Description = "This role requires advanced ability to make concrete stories out of vague requirements.", Experience = "Senior Level"},
        new JobModel {Company = "Neflix", Title = "Senior Software Engineer II", Description = "This role requires skill like java, kubernetes, and knowledge of building streaming platforms.", Experience = "Senior Level"}
    };

    [KernelFunction("get_jobs")]
    public async Task<List<JobModel>> GetJobsAsync() {
        return jobs;
    }
}
using IssueTracker.Core.Models;

namespace IssueTracker.Core.Services;

public class ProjectService(MockDataStore store)
{
    public Task<List<Project>> GetAllAsync()
    {
        return Task.FromResult(store.Projects);
    }

    public Task<Project?> GetByIdAsync(Guid id)
    {
        var project = store.Projects.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(project);
    }

    public Task CreateAsync(Project project)
    {
        project = project with { Id = Guid.NewGuid() };
        store.Projects.Add(project);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Project project)
    {
        var existingProject = store.Projects.FirstOrDefault(p => p.Id == project.Id);
        if (existingProject != null)
        {
            store.Projects.Remove(existingProject);
            store.Projects.Add(project);
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var project = store.Projects.FirstOrDefault(p => p.Id == id);
        if (project != null)
        {
            store.Projects.Remove(project);
        }
        return Task.CompletedTask;
    }

    Task<bool> ExistsAsync(Guid id)
    {
        var exists = store.Projects.Any(p => p.Id == id);
        return Task.FromResult(exists);
    }
}
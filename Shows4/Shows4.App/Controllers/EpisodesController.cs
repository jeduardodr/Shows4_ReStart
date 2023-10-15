namespace Shows4.App.Controllers;

public class EpisodesController : Controller
{
    // ... outras ações ...

    public IActionResult AddCast(int id)
    {
        // 'id' é o ID do episódio ao qual você deseja adicionar o elenco
        // Você pode usar 'id' para carregar o episódio do banco de dados se necessário

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCast(int id, Cast cast)
    {
        // 'id' é o ID do episódio ao qual você está adicionando o elenco
        // 'cast' é o membro do elenco que está sendo adicionado

        // Adicione o novo membro do elenco ao episódio e salve as alterações no banco de dados

        return RedirectToAction("Index");
    }
}

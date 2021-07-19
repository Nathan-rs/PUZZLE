using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    [SerializeField] private Transform empty = null;
    [SerializeField] private TilesScript[] tiles;
    [SerializeField] private TilesScript[] RegraTile;
    private int emptySpaceIndex = 15;
    private bool winControle = false;
    private Camera _camera;
    // public string nomeCena;
    void Start()
    {
        _camera = Camera.main;
        Shuffler();
        ShuffleRegra();
    }

    // Update is called once per frame
    void Update()
    {
        SwapController();
    }


    void SwapController(){
        if(winControle == false){
            swap();
        }else{
           return;
        }
    }

    void swap(){
            if(Input.GetMouseButtonDown(0)){
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if(hit){
                    if(Vector2.Distance(emptySpace.position, hit.transform.position) < 2){
                        Vector2 lastEmptySpacePosition = emptySpace.position;
                        TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                        emptySpace.position = thisTile.targetPosition;
                        thisTile.targetPosition = lastEmptySpacePosition;
                        int tileIndex = findIndex(thisTile);
                        tiles[emptySpaceIndex] = tiles[tileIndex];
                        tiles[tileIndex] = null;
                        emptySpaceIndex = tileIndex;
                    }
                }
            }
    }
    public void Shuffler() {
        int invertion;

        if(emptySpaceIndex != 15){
            var tileon15LastPos = tiles[15].targetPosition;
            tiles[15].targetPosition = emptySpace.position;
            emptySpace.position = tileon15LastPos;
            tiles[emptySpaceIndex] = tiles[15];
            tiles[15] = null;
            emptySpaceIndex = 15;
        }

        do{
            for(int i=0; i<=14; i++){
                if(tiles[i] != null){
                    var lastPos = tiles[i].targetPosition;
                    int randowIndex = Random.Range(0, 14);
                    tiles[i].targetPosition = tiles[randowIndex].targetPosition;
                    tiles[randowIndex].targetPosition = lastPos;
                    var tile = tiles[i];
                    tiles[i] = tiles[randowIndex];
                    tiles[randowIndex] = tile;
                }
            }
            invertion = GetInversions();
        }while(invertion%2 !=0);
    }

    public void ShuffleRegra(){
        int invertion;

         if(emptySpaceIndex != 15){
            var tileon15LastPos = tiles[15].targetPosition;
            tiles[15].targetPosition = empty.position;
            empty.position = tileon15LastPos;
            tiles[emptySpaceIndex] = tiles[15];
            tiles[15] = null;
            emptySpaceIndex = 15;
        }

        do{
        for(int i=0; i<=14; i++){
            if(RegraTile[i] != null){
                var lastPos = RegraTile[i].targetPosition;
                int randowIndex = Random.Range(0, 14);
                RegraTile[i].targetPosition = RegraTile[randowIndex].targetPosition;
                RegraTile[randowIndex].targetPosition = lastPos;
                var tile = RegraTile[i];
                RegraTile[i] = RegraTile[randowIndex];
                RegraTile[randowIndex] = tile;
            }
        }
        invertion = GetInversions();
        }while(invertion%2 != 0);
    }

    public int findIndex(TilesScript ts) {
        for(int i =0; i< tiles.Length; i++) {
            if(tiles[i] != null) {
                if(tiles[i] == ts) {
                    return i;
                }
            }
        }
        return -1;
    }

    

int GetInversions() {
        int inversionsSum = 0;
        for (int i = 0;i < tiles.Length;i++) {
            int thisTileInvertion = 0;

            for (int j = i; j < tiles.Length; j++) {
                if (tiles[j] != null) {
                    if (tiles[i].number > tiles[j].number) {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }
    
    public void isWin(){
        int cont = 0;
        if(tiles[15] == null){
            for(int i=0; i<=14; i++){
                if(tiles[i].flag == true){
                    cont++;
                }else{
                    cont = 0;
                }
            }
        }
        winControle = cont == 15? true: false;
    }

    // void showWin(){
    //     isWin();

    //     if(winControle == true){
    //         SceneManager.LoadScene(nomeCena);
    //     }
    // }
    public bool getwinControlle(){
        return winControle;
    }

    public void setwinControlle(bool controlle){
        this.winControle = controlle;
    }
}

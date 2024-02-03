using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Episode   //인카운터가 모여 에피소드를 이루고, 에피소드가 모여 게임스토리를 이루는 구조를 계획 중
{
    public string name;
    public List<Encounter> episode = new List<Encounter>();

    public List<Encounter> PossibleEpisode  //선행조건을 만족한 인카운터만 추출
    {
        get { return episode.Where(ep => ep.precondition).ToList(); }
    }

    public Encounter GetRandomEncounter     //선행조건을 만족한 인카운터 중 랜덤으로 하나 뽑기
    {
        get { return PossibleEpisode[Random.Range(0, PossibleEpisode.Count)]; }
    }
}

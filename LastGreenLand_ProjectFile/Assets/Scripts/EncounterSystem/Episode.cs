using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Episode   //��ī���Ͱ� �� ���Ǽҵ带 �̷��, ���Ǽҵ尡 �� ���ӽ��丮�� �̷�� ������ ��ȹ ��
{
    public string name;
    public List<Encounter> episode = new List<Encounter>();

    public List<Encounter> PossibleEpisode  //���������� ������ ��ī���͸� ����
    {
        get { return episode.Where(ep => ep.precondition).ToList(); }
    }

    public Encounter GetRandomEncounter     //���������� ������ ��ī���� �� �������� �ϳ� �̱�
    {
        get { return PossibleEpisode[Random.Range(0, PossibleEpisode.Count)]; }
    }
}

public class Solution {
    public int PrefixCount(string[] words, string pref) {
        Trie trie = new Trie();
        foreach(string word in words){
            trie.Insert(word);
        }
        return trie.CountWordsWithPrefix(pref);
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    public int wordCount = 0;
}

public class Trie {
    private TrieNode root;

    public Trie(){
        root = new TrieNode();
    }

    public void Insert(string word){
        TrieNode current = root;

        foreach(char ch in word){
            if(!current.children.ContainsKey(ch)){
                current.children[ch] = new TrieNode();
            }
            current = current.children[ch];
        }
        current.wordCount++;
    }

    public int CountWordsWithPrefix(string prefix){
        TrieNode current = root;
        foreach(char ch in prefix){
            if(!current.children.ContainsKey(ch)){
                return 0;
            }
            current = current.children[ch];
        }
        return CountWords(current);
    }

    private int CountWords(TrieNode current){
        int count = current.wordCount;
        foreach(TrieNode child in current.children.Values){
            count+= CountWords(child);
        }
        return count;
    }
}
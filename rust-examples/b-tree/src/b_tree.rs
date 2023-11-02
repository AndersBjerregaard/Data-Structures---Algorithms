struct BTree {

}

#[derive(Debug)]
struct Node {
    value: usize,
    key: Vec<u32>,
    child: Vec<Node>,
    leaf: bool,
}

#[derive(Debug)]
enum BTreeError {
    NotFound,
}

impl std::error::Error for BTreeError {}

impl std::fmt::Display for BTreeError {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        match self {
            BTreeError::NotFound => write!(f, "Key not found in B-Tree"),
        }
    }
}

fn btree_search(x: &Node, k: u32) -> Result<&Node, BTreeError> {
    let mut i: usize = 0;
    while i < x.value && k >= x.key[i] {
        i = i + 1;
    }
    if i < x.value && k == x.key[i] {
        return Ok(x);
    }
    if x.leaf {
        return Err(BTreeError::NotFound);
    }
    btree_search(&x.child[i], k)
}
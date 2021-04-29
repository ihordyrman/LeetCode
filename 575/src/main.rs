use std::collections::HashSet;

// 575. Distribute Candies
// https://leetcode.com/problems/distribute-candies/
fn main() {
    assert_eq!(distribute_candies(vec![1,1,2,2,3,3]), 3);
    assert_eq!(distribute_candies(vec![1,1,2,3]), 2);
    assert_eq!(distribute_candies(vec![6,6,6,6]), 1);
}

pub fn distribute_candies(candy_type: Vec<i32>) -> i32 {
    let max_candies = candy_type.len() / 2;

    let mut hash_set: HashSet<i32> = HashSet::new();

    let mut index = 0;

    while index < candy_type.len() {
        hash_set.insert(candy_type[index]);

        if hash_set.len() == max_candies {
            return max_candies as i32;
        }

        index += 1;
    }

    hash_set.len() as i32
}

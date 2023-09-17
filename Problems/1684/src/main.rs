// 1684. Count the Number of Consistent Strings
// https://leetcode.com/problems/count-the-number-of-consistent-strings/
fn main() {
    assert_eq!(
        count_consistent_strings(
            String::from("ad"),
            vec![
                String::from("ad"),
                String::from("bd"),
                String::from("aaab"),
                String::from("baa"),
                String::from("badab")
            ]
        ),
        2
    );

    assert_eq!(
        count_consistent_strings(
            String::from("abc"),
            vec![
                String::from("a"),
                String::from("b"),
                String::from("c"),
                String::from("ab"),
                String::from("ac"),
                String::from("bc"),
                String::from("abc")
            ]
        ),
        7
    );
}

pub fn count_consistent_strings(allowed: String, words: Vec<String>) -> i32 {
    let mut count = 0;

    for word in words.iter() {
        count += 1;

        for ch in word.chars() {

            let mut flag = true;

            for allowed_char in allowed.chars() {
                if allowed_char == ch {
                    flag = false;
                }
            }

            if flag {
                count -= 1;
                break;
            }
        }
    }

    count
}
